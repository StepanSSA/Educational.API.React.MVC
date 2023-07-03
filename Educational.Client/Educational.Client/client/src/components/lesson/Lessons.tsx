import { useContext, useState } from "react"
import { Client, LessonsForCourseDetailVm } from "../../api/api"
import { HubContext } from "../chat/HubContext";

const lessonVideoUrl = "https://localhost:7083/api/Lesson/GetLessonVideo/Lesson/video?lessonId="

interface IProp{
    Lessons: LessonsForCourseDetailVm[] | undefined
    teacherId: string
}

const Lessons = (prop: IProp) => {
    const hubCtx = useContext(HubContext);

    const apiClient = new Client("https://localhost:7083")
    const [activeLesson, setActiveLesson] = useState<number>(0)
    const [file, setFile] = useState<File>();
    const [videoPath, setvideoPath] = useState<string>("")
    const [modalVis, SetModalVis] = useState<boolean>(false);
    const [message, setMessage] = useState<string>("")

    if(videoPath == "")
        setvideoPath(String(prop.Lessons?.[activeLesson].videoPath))

    function Modal(visible : boolean)
    {
        if(visible)
        {
            return(
            <div className="modal" onClick={() => SetModalVis(false)}>
                <div className='modalContent' onClick={e => e.stopPropagation()}>
                    <h5>Сообщение преподавателю</h5>
                    <div className="form-group">
                        <label htmlFor="exampleFormControlTextarea1"></label>
                        <textarea onChange={(e) => setMessage(e.target.value)} className="form-control" id="exampleFormControlTextarea1"></textarea>
                    </div>
                    <br></br>
                    <div>
                        <button onClick={SendMessage} className="TeacherBtn">
                            Отправить
                        </button>
                    </div>
                </div>
            </div>
            )
        }
        else
        {
            return
        }
    }

    console.log("videoPath == ", videoPath)
    return(
        <div className="LessonsBlock">
            {Modal(modalVis)}
        <div className="LessonText col">
                        <h3>{prop.Lessons?.[activeLesson]?.name}</h3>
                        <p>{prop.Lessons?.[activeLesson]?.description}</p>
                    </div>
            <div className="container">
                <div className="row">
                    <div className="col" style={{padding: "1rem"}}>
                        <video className="Video" controls >
                            <source src={videoPath}>
                            </source>
                        </video>
                    </div>
                    <div className="col-mb-2">
                        <div className="">
                            <h5>Домашнее задание</h5>
                        </div>
                        <div className="row align-self-end">
                            <div className="input-group mb-3 " style={{maxHeight: "2rem"}}>
                                <input onChange={(e) => addFile(e)} type="file" className="form-control" id="formFile"/>
                                <label className="form-label" htmlFor="formFile"></label>
                            </div>
                        </div>
                        <div className="row align-self-end" style={{padding: "1rem"}}>
                            <button className="ChengeLessonBtn" onClick={() => SendHomework()} type="button">Отправить</button>
                        </div>
                    </div>
                </div>
                <div className="row">
                    <div className="col">
                        <button className="row ChengeLessonBtn" type="button" onClick={() => ChangeLesson(-1)}>Предыдущий урок</button>
                    </div>
                    <div className="col">
                        <button className="col ChengeLessonBtn" type="button" onClick={() => ChangeLesson(1)}>Следующий урок</button>
                    </div>
                </div>
                <br></br>
                <div className="row justify-content-md-center" style={{justifyContent: "center"}}>
                    <button onClick={() => SetModalVis(!modalVis)} className="TeacherBtn">Написать учителю</button>
                </div>
            </div> 
        </div>
    )

    function ChangeLesson(value: number)
    {
        var newActiveLesson = activeLesson + value
        if(newActiveLesson >= Number(prop.Lessons?.length) || newActiveLesson < 0)
            newActiveLesson = 0
        setActiveLesson(newActiveLesson)
        setvideoPath(lessonVideoUrl+prop.Lessons?.[newActiveLesson].id)
        console.log(videoPath)
    }

    function addFile(event: any) {

        event.preventDefault();
        if (event.target.files[0]) {
            setFile(event.target.files[0])
        }
    }

    function SendHomework()
    {
        if(file === null || file === undefined){
            alert("Файл не выбран")
            return
        }
        var userId = localStorage.getItem('userId');
        apiClient.uploadHomework(prop.Lessons?.[activeLesson].id, String(userId), file).then(() => {
            var t = document.getElementById("")
            alert("успешно")
        }).catch(()=>{
            alert("Что-то пошло не так")
        })
    }

    async function SendMessage()
    {
        var userId = localStorage.getItem('userId');
        if(userId === null && userId === undefined)
        {
            alert("Ошибка")
            return;
        }
        await hubCtx?.connection?.invoke("SendMessageRecipientAsync", userId, message, prop.teacherId)
        SetModalVis(false);
    }
}

export default Lessons