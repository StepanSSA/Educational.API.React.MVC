import { useState } from "react";
import { Client, CourseLookupDto } from "../../../api/api";
import CourseItem from "../../course/courseItem";

const CourseData = () =>{
    const apiClient = new Client("https://localhost:7083");
    const [courses, setCourse] = useState<CourseLookupDto[]>([]);
    if(courses.length < 1)
    {
        var userId = localStorage.getItem('userId');
        apiClient.getUsersCourse(String(userId)).then((value) => {
            setCourse(value)
        });
        
    }
    return(
        <div style={{minHeight: "600px"}}>
            <div className="CourseListHeader">
                <h1>Курсы</h1>
            </div>
            <div className="CourseListCourses">
                {courses?.map(item => (
                    <ul>
                        <CourseItem id={item.id} Description={item.description} Duration={0} Name={item.name} Price={item.price}/>
                    </ul>
                ))}
            </div>
        </div>
    )
}

export default CourseData