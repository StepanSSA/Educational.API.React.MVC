import { useState } from "react";
import { Client, CreateCourseDto, TeacherForCourseDetailVm} from "../../../api/api";
import { useNavigate } from "react-router";

interface CreateLessonDto{
    number: number | undefined,
    name: string | undefined,
    description: string | undefined,
    video: File | undefined
}


const CreateCourse = () => {
    const navigation = useNavigate()
    const [courseId, setCourseId] = useState<string>()
    const apiClient = new Client("https://localhost:7083")

    const [teachers, setTeachers] = useState<TeacherForCourseDetailVm[]>([])
    if(teachers.length < 1)
        apiClient.getTeachers().then(value => {
            if(value.length > 1)
            {
                setTeachers(value)
                setCourseTeacher(String(teachers[0].userId))
            }
        });

    const [lessons, setLessons] = useState<CreateLessonDto[]>([])
    const [courseName, setCourseName] = useState<string>("")
    const [courseDesc, setCourseDesc] = useState<string>("")
    const [coursePrice, setCoursePrice] = useState<number>(0)
    const [courseTeacher, setCourseTeacher] = useState<string>("72743aab-00ee-4208-8056-260cea461cb2")

    const [courseSaved, setCourseSaved] = useState<boolean>(false)

    return(
        <div style={{position: "relative", width: "50%", margin: "auto", marginTop: "2rem"}}>
            <form>
                <div>
                    <h3>Курс</h3>
                </div>
                <div className="mb-3">
                    <label htmlFor="exampleFormControlInput1" className="form-label">Название курса</label>
                    <input readOnly={courseSaved} onChange={(e) => setCourseName(e.target.value)} type="text" className="form-control" id="exampleFormControlInput1"/>
                </div>
                <div className="mb-3">
                    <label htmlFor="exampleFormControlInput1" className="form-label">Описание</label>
                    <input readOnly={courseSaved} onChange={(e) => setCourseDesc(e.target.value)} type="text" className="form-control" id="exampleFormControlInput1"/>
                </div>
                <div className="mb-3">
                    <label htmlFor="exampleFormControlInput1" className="form-label">Цена</label>
                    <input readOnly={courseSaved} onChange={(e) => setCoursePrice(Number(e.target.value))} type="number" min={0} className="form-control" id="exampleFormControlInput1"/>
                </div>
                <div className="mb-3">
                <label htmlFor="TSelect" className="form-label">Учитель</label>
                <select onChange={(e) => SelectTeacher(e.currentTarget.value)} className="form-select" id="TSelect" aria-label="Default select example">
                    {teachers.map(item => (
                        <option value={item.userId}>{item.name}</option>
                    ))}
                </select>    
                </div>
                <div className="mb-3">
                    <label htmlFor="exampleFormControlInput1" className="form-label">Длительность</label>
                    <input readOnly={courseSaved} type="number" onChange={(e) => ChangeDuration(Number(e.target.value))} min={0} className="form-control" id="exampleFormControlInput1"/>
                </div>
                <button className="btn btn-outline-success" type="button" onClick={() => SaveCourse()}>Сохранить курс</button>
                <br></br>
                <div>
                    <h3>Уроки</h3>
                </div>
                <div>
                    {lessons.map(item => (
                    <div>
                        <div className="mb-3">
                            <label htmlFor="exampleFormControlInput1" className="form-label">Название</label>
                            <input onChange={(e) => AddLessonName(e.target.value, Number(item.number))} className="form-control" id="exampleFormControlInput1"/>
                        </div>
                        <div className="mb-3">
                            <label htmlFor="exampleFormControlInput1" className="form-label">Описание</label>
                            <input onChange={(e) => AddLessonDesc(e.target.value, Number(item.number))} className="form-control" id="exampleFormControlInput1"/>
                        </div>
                        <div className="mb-3">
                            <label htmlFor="exampleFormControlInput1" className="form-label">Номер</label>
                            <input type="number" readOnly defaultValue={item.number} min={0} className="form-control" id="exampleFormControlInput1"/>
                        </div>
                        <div className="input-group mb-3">
                            <input accept="video/mp4" onChange={(e) => addVideo(e, Number(item.number))} type="file" className="form-control" id="inputGroupFile02"/>
                            <label className="input-group-text" htmlFor="inputGroupFile02">Видео</label>
                        </div>
                        <br></br>
                    </div>
                    ))}
                    <button className="btn btn-outline-success" type="button" onClick={() => SaveLessons()}>Сохранить уроки</button>
                </div>
                <br/>
            </form>
        </div>
    )
    
    function SelectTeacher(id :string)
    {
        setCourseTeacher(id);
        console.log("id =>")
        console.log(id)
        console.log("courseTeacher =>")
        console.log(courseTeacher)
    }

    function ChangeDuration(value: number)
    {
        var les: CreateLessonDto[] = []
        setLessons(les)

        for (let index = 0; index < value; index++) {
            var data: CreateLessonDto = {
                name: "1",
                number: index+1,
                description: "1",
                video : undefined
            }
            les.push(data)
        }
        setLessons(les)
        console.log(lessons.length);
    }

    function addVideo(event: any, lessonNumber: number) {
        const les = lessons;

        event.preventDefault();
        if (event.target.files[0]) {
            les[lessonNumber-1].video = event.target.files[0]
        }
    }

    function AddLessonName(Name :string, lessonNumber: number | 1)
    {
        const les = lessons;
        les[lessonNumber-1].name = Name
        setLessons(les);
    }
    function AddLessonDesc(Desc :string, lessonNumber: number)
    {
        const les = lessons;
        les[lessonNumber-1].description = Desc
        setLessons(les);
    }
    
    function SaveCourse()
    {
        if(courseSaved)
            return;

        var id = crypto.randomUUID()
        setCourseId(id)

        var t: CreateCourseDto = {
            description: courseDesc,
            id: courseId,
            price: coursePrice,
            name: courseName,
            duration: lessons.length,
            teacherId: courseTeacher
        }

        console.log(t)

        apiClient
        .createCourse(t).then(value => {
            setCourseId(value);
            window.alert("Курс сохранён")
        })
        setCourseSaved(true);
    }

    function SaveLessons()
    {
        if(courseSaved)
        {
            for (let index = 0; index < lessons.length; index++) {
                apiClient.createLesson(lessons[index].name, lessons[index].description, lessons[index].video, courseId, lessons[index].number)
            }
            navigation('/CourseTable')
        }
        else
            window.alert("Курс не сохранён")
    }
}

export default CreateCourse