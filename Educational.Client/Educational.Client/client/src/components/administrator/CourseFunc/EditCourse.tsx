import { useState } from "react";
import { Client, TeacherForCourseDetailVm, UpdateCourseDto, UpdateLessonDto } from "../../../api/api";
import { useNavigate, useParams } from "react-router-dom";

const EditCourse = () => {
    const params = useParams();
    const apiClient = new Client("https://localhost:7083")
    const navigation = useNavigate() 
    
    const [lessons, setLessons] = useState<UpdateLessonDto[]>([])
    const [courseName, setCourseName] = useState<string>("")
    const [courseDesc, setCourseDesc] = useState<string>("")
    const [coursePrice, setCoursePrice] = useState<number>(0)
    const [courseConfirm, setCourseConfirm] = useState<boolean>(false)
    const [courseTeacher, setCourseTeacher] = useState<string>()
    const [courseTeacherName, setCourseTeacherName] = useState<string>("")
    const [courseConfirmText, setCourseConfirmText] = useState<string>("true")

    const [allTeachers, setAllTeachers] = useState<TeacherForCourseDetailVm[]>([])

    if(lessons.length < 1)
    {
        const id = params.id?.split(":",2)[1];
        apiClient.getLessons(id).then(value => {
            const les: UpdateLessonDto[] = []
            for (let index = 0; index < value.length; index++) {
                const newLesson: UpdateLessonDto = {
                    description: value[index].description,
                    name: value[index].name,
                    number: index+1,
                    id: value[index].id
                }
                console.log("les Id")
                console.log(newLesson.id)
                les.push(newLesson)
            }
            setLessons(les)
        })
        apiClient.getTeachers().then(value => {
            if(value.length > 1)
            {
                setAllTeachers(value)
            }
        });

        apiClient.getCourse(String(id)).then(value => {
            setCourseConfirm(Boolean(value.confirmed))
            setCourseDesc(String(value.description))
            setCourseName(String(value.name))
            setCoursePrice(Number(value.price))
            setCourseTeacher(String(value.teacher?.userId))

            if(Boolean(value.confirmed))
                setCourseConfirmText("Да")
            else
                setCourseConfirmText("Нет")
            
            
            allTeachers.forEach(element => {
                if(element.userId === value.teacher?.userId)
                    setCourseTeacherName(String(value.teacher?.name))
            });
        })
    }

    return(
        <div style={{position: "relative", width: "50%", margin: "auto", marginTop: "2rem"}}>
            <form>
                <button className="btn btn-outline-success" onClick={() => SaveCourse()} type="button">Сохранить</button>
                <div>
                    <h3>Курс</h3>
                </div>
                <div className="mb-3">
                    <label htmlFor="exampleFormControlInput1" className="form-label">Название курса</label>
                    <input onChange={(e) => setCourseName(e.target.value)} type="text" defaultValue={courseName} className="form-control" id="exampleFormControlInput1"/>
                </div>
                <div className="mb-3">
                    <label htmlFor="exampleFormControlInput1" className="form-label">Описание</label>
                    <input onChange={(e) => setCourseDesc(e.target.value)} type="text" defaultValue={courseDesc} className="form-control" id="exampleFormControlInput1"/>
                </div>
                <div className="mb-3">
                    <label htmlFor="exampleFormControlInput1" className="form-label">Цена</label>
                    <input onChange={(e) => setCoursePrice(Number(e.target.value))} type="number" value={coursePrice} min={0} className="form-control" id="exampleFormControlInput1"/>
                </div>
                <div className="mb-3" hidden>
                    <label htmlFor="ConfirmSelect" className="form-label">Прошёл проверку</label>
                    <select onChange={(e) => ConfirmCourse(e.currentTarget.value)} className="form-select" id="ConfirmSelect">
                        <option selected>{courseConfirmText}</option>
                        <option value={"true"}>Да</option>
                        <option value={"false"}>Нет</option>
                </select>    
                </div>
                <div className="mb-3">
                    <label htmlFor="TeacherSelect" className="form-label">Преподаватель</label>
                    <select onChange={(e) => SelectTeacher(e.currentTarget.value)} className="form-select" id="TeacherSelect">
                        <option selected>{String(courseTeacherName)}</option>
                        {allTeachers.map(item => (
                            <option value={item.userId}>{item.name}</option>
                        ))}
                </select>    
                </div>
                <br></br>
                <div>
                    <h3>Уроки</h3>
                </div>
                <div>
                    {lessons.map(item => (
                    <div>
                        <div className="mb-3">
                            <label htmlFor="exampleFormControlInput1" className="form-label">Название</label>
                            <input onChange={(e) => AddLessonName(e.target.value, Number(item.number))} defaultValue={item.name} className="form-control" id="exampleFormControlInput1"/>
                        </div>
                        <div className="mb-3">
                            <label htmlFor="exampleFormControlInput1" className="form-label">Описание</label>
                            <input onChange={(e) => AddLessonDesc(e.target.value, Number(item.number))} defaultValue={item.description} className="form-control" id="exampleFormControlInput1"/>
                        </div>
                        <div className="mb-3">
                            <label htmlFor="exampleFormControlInput1" className="form-label">Номер</label>
                            <input type="number" readOnly defaultValue={item.number} min={0} className="form-control" id="exampleFormControlInput1"/>
                        </div>
                        <br></br>
                    </div>
                    ))}
                </div>
            </form>
        </div>
    )
    
    function ConfirmCourse(value: string)
    {
        switch (value) {
            case "true":
                setCourseConfirm(true)
                break;
            case "false":
                setCourseConfirm(false)
                break;
        }
    }

    function SelectTeacher(id :string)
    {
        setCourseTeacher(id);
        console.log("id =>")
        console.log(id)
        console.log("courseTeacher =>")
        console.log(courseTeacher)
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

        var t: UpdateCourseDto = {
            description: courseDesc,
            price: coursePrice,
            name: courseName,
            duration: lessons.length,
            confirmed: courseConfirm,
            teacherId: courseTeacher,
            id: params.id?.split(":",2)[1]
        }

        console.log(t)
        
        apiClient.updateCourse(t).then(value => {
            if(value)
                SaveLessons()
            else
                window.alert("Что-то пошло не так")
        });
    }

    function SaveLessons()
    {
        for (let index = 0; index < lessons.length; index++) {
            apiClient.updateLesson(lessons[index]);
        }
        navigation('/CourseTable')
    }
}

export default EditCourse