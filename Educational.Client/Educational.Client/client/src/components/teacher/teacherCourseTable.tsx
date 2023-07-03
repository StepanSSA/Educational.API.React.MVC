import { useState } from "react";
import { Client, CourseLookupDto } from "../../api/api";

const TeacherCourseTable = () => {
    const apiClient = new Client("https://localhost:7083");
    const [courses, setCourse] = useState<CourseLookupDto[]>([]);
    if(courses.length < 1)
    {
        const userId = localStorage.getItem('userId')
        apiClient.getTeacherCourses(String(userId)).then((value) => {
            setCourse(value)
            console.log(value[0].id)
        });
    }
    return(
        <div style={{margin: "2rem", padding: "1rem"}}>
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
                            <a type="button" href={"/HomeworkTable/:" + item.id} className="CourseTableBtnCreate">Таблица домашних заданий</a>
                        </td>
                    </tr>
                    ))}
                </tbody>
            </table>
        </div>
    )
}

export default TeacherCourseTable