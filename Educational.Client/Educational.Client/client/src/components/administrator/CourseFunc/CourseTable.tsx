import { useState } from "react";
import { Client, CourseLookupDto } from "../../../api/api";
import '../adminPage.css'

const CourseTable = () => {
    const apiClient = new Client("https://localhost:7083");
    const [courses, setCourse] = useState<CourseLookupDto[]>([]);
    if(courses.length < 1)
    {
        apiClient.getCourses().then((value) => {
            setCourse(value)
        });
        
    }
    return(
        <div style={{margin: "2rem", padding: "1rem"}}>
            <a type="button" href="/CreateCourse" className="CourseTableBtnCreate">Создать</a>
            <table className="table">
                <thead>
                    <tr>
                        <th scope="col">Id</th>
                        <th scope="col">Название</th>
                        <th scope="col">Описание</th>
                        <th scope="col">Цена</th>
                        <th scope="col">Функции</th>
                    </tr>
                </thead>
                <tbody>
                    {courses?.map(item => (
                        <tr>
                        <th scope="row">{item.id}</th>
                        <td>{item.name}</td>
                        <td>{item.description}</td>
                        <td>{item.price}</td>
                        <td> 
                            <a type="button" href={"/EditCourse/:" + item.id} className="CourseTableBtnEdit">Редактировать</a>
                            <button onClick={() => RemoveCourse(String(item.id))} className="CourseTableBtnDel">Удалить</button>
                        </td>
                    </tr>
                    ))}
                </tbody>
            </table>
        </div>
    )

    function RemoveCourse(id: string)
    {
        if(window.confirm("Удалить курс?"))
        {
            apiClient.deleteCourse(id).then(value =>{
                if(value)
                    window.location.reload();
                else
                    window.alert("Что-то пошло не так")
            });
            
        }

    }

}

export default CourseTable