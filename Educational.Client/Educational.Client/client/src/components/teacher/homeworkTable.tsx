import { useState } from "react";
import { Client, CourseHomeworkLookupDto } from "../../api/api";
import { useParams } from "react-router-dom";

const HomeworkTable = () => {
    const params = useParams();
    const apiClient = new Client("https://localhost:7083");
    const [homeworks, setHomework] = useState<CourseHomeworkLookupDto[]>([]);
    
    if(homeworks.length < 1)
    {
        const id = params.id?.split(":",2)[1];
        apiClient.getCourseHomework(id).then((value) => {
            setHomework(value)
        });
    }
    return(
        <div style={{minHeight:"600px", margin: "2rem", padding: "1rem"}}>
            <table className="table">
                <thead>
                    <tr>
                        <th scope="col">Ученик</th>
                        <th scope="col">Урок</th>
                        <th scope="col">Дата</th>
                        <th scope="col">Оценка</th>
                        <th scope="col">Домашнее задание</th>
                    </tr>
                </thead>
                <tbody>
                    {homeworks?.map(item => (
                        <tr>
                        <th scope="row">{item.studentName}</th>
                        <td>{item.lessonName}</td>
                        <td>{DateFormat(String(item.date))}</td>
                        <td>
                            <select onChange={(e) => ChangeScore(e.currentTarget.value, String(item.id))} className="form-select" style={{maxWidth: "4rem"}}>
                                <option selected>{item.score}</option>
                                <option value="1">1</option>
                                <option value="2">2</option>
                                <option value="3">3</option>
                                <option value="4">4</option>
                                <option value="5">5</option>
                            </select>
                        </td>
                        <td> 
                            <a type="button" href={"https://localhost:7083/api/Homework/GetHomeworkFile/homeworkFile?homeworkId="+ String(item.id)} className="CourseTableBtnCreate">Скачать</a>
                        </td>
                    </tr>
                    ))}
                </tbody>
            </table>
        </div>
    )

    function DateFormat(date : string)
    {
        const dateString = date.split("T")[0].split('-')
        return String(dateString[2] + "." + dateString[1] + "." + dateString[0])
    }

    function ChangeScore(newScore: string, homeworkId: string)
    {
        console.log("homework Id = " + homeworkId)
        console.log("new Score" + newScore)
        apiClient.changeScroe(homeworkId, Number(newScore))
    }
}

export default HomeworkTable;