import { useState } from "react"
import { CourseLookupDto } from "../../api/api"
import CourseItem from "./courseItem"
import './courseList.css'
import { Client } from "../../api/api"

const CourseList = () => {
    const apiClient = new Client("https://localhost:7083");
    const [courses, setCourse] = useState<CourseLookupDto[]>([]);
    if(courses.length < 1)
    {
        apiClient.getCourses().then((value) => {
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

export default CourseList