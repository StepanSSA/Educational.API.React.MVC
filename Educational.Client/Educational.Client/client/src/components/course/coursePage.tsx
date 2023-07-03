import { useContext, useRef, useState } from "react";
import { useParams } from "react-router-dom";
import { Client, CourseDetailVm, CourseLookupDto, LessonsForCourseDetailVm } from "../../api/api";
import './coursePage.css'
import '../lesson/Lessons.css'
import './MessageModal.css'
import { HubContext } from "../chat/HubContext";
import { UserManager } from "oidc-client";
import Lessons from "../lesson/Lessons";
import Ads from "../home/ads";
import CourseAds from "../home/CourseAds";

const lessonVideoUrl = "https://localhost:7083/api/Lesson/GetLessonVideo/Lesson/video?lessonId="


const CoursePage = ()=> {

    const hubCtx = useContext(HubContext);

    const params = useParams();
    const [course, setCourse] = useState<CourseDetailVm>()
    const [userCourses, SetUserCourses] = useState<CourseLookupDto[]>([])
    const [loadUserCourse, setLoadUserCourse] = useState<boolean>(true)

    const apiClient = new Client("https://localhost:7083")
    
    if(loadUserCourse)
    {       
        apiClient.getUsersCourse(String(localStorage.getItem('userId'))).then(value => {
            SetUserCourses(value);
            setLoadUserCourse(false)
        }).catch(() => {
            setLoadUserCourse(false)
        })
    }
    

    if(course === undefined)
    {
        const path = params.id?.split(":",2)[1];
        apiClient.getCourse(path as string).then((value) => {
            setCourse(value);
        });
    }

    console.log("course", course)
    console.log("userCourses", userCourses)
    for (let index = 0; index < userCourses.length; index++) {
        if(userCourses[index].id == course?.id)
        {
            return(
                <Lessons Lessons={course?.lessons} teacherId={String(course?.teacher?.userId)}/>
            )
        }
    }


    return(
        <div style={{minHeight: "700px"}}>
        <div  className="CoursePage">
            <div className="CourseNameBlock">
                <h1>{course?.name}</h1>
                <div className="CourseDescriptionBlock">
                    <p>{course?.description}</p>
                </div>
            </div>
            <div className="CoursePriceBlock">
                <div className="Price">
                    <h3>{course?.price}</h3>
                </div>
                <ul>
                    <li>Рассрочка до 36 месяцев</li>
                    <li>Платеж через 1 месяц</li>
                    <li>Бесплатное менторство</li>
                </ul>
                <a type="button" className="BuyBtn" href={"/BuyCourse/:"+ course?.id}> Записаться </a>
            </div>
            <div>
        </div>
        
        </div>
        <CourseAds></CourseAds>
        <Ads></Ads>
        </div>
    )

}

export default CoursePage

