import { useState } from "react";
import { Client, HomeworkDescription } from "../../../api/api"

const ScoreData = () =>
{
    const apiClietn = new Client("https://localhost:7083")

    const [score, SetScore] = useState<HomeworkDescription[]>([])
    const [loadScore, SetLoadScore] = useState<boolean>(true);
    const [returnTable, SetReturnTable] = useState<boolean>(true);

    if(loadScore)
    {
        const userId = localStorage.getItem('userId');
        apiClietn.getDescription(String(userId)).then(value => {
            SetScore(value);
            SetLoadScore(false)
        }).catch(() => {
            SetLoadScore(false)
            SetReturnTable(true)
        });
    }
    
    if(returnTable)
    {
        return(
            <div style={{margin: "2rem", padding: "1rem", minHeight: "600px"}}>
            <table className="table">
                <thead>
                    <tr>
                        <th scope="col">Курс</th>
                        <th scope="col">Урок</th>
                        <th scope="col">Дата</th>
                        <th scope="col">Оценка</th>
                    </tr>
                </thead>
                <tbody>
                    {score?.map(item => (
                        <tr>
                        <th scope="row">{item.courseName}</th>
                        <td>{item.lessonName}</td>
                        <td>{String(item.date?.toString().split("T")[0])}</td>
                        <td>{item.score}</td>
                    </tr>
                    ))}
                </tbody>
            </table>
        </div>
        )
    }
    else
    {
        return(
            <div style={{width: "100%", minHeight: "600px"}}>
                <h5>У вас пока нет оценок</h5>
            </div>
        )
        
    }
    
}

export default ScoreData