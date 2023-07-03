import { FC, ReactElement, useContext, useEffect} from "react";
import { loadUser} from "./auth/user-service";
import Home from './components/home/home'
import { BrowserRouter as Router, Route } from 'react-router-dom';
import { Routes } from 'react-router-dom';
import AuthProvider from "./auth/auth-provider";
import CourseList from './components/course/courseList';
import ProfilePage from './components/profile/profilePage';
import AdministratorPage from './components/administrator/adminPage';
import userManager from "./auth/user-service";
import SignInOidc from "./auth/SignInOidc";
import SignOutOidc from "./auth/SignoutOidc";
import CoursePage from "./components/course/coursePage";
import CourseTable from "./components/administrator/CourseFunc/CourseTable";
import CreateCourse from "./components/administrator/CourseFunc/CreateCourse";
import EditCourse from "./components/administrator/CourseFunc/EditCourse";
import TeacherPage from "./components/teacher/teacherPage";
import TeacherCourseTable from "./components/teacher/teacherCourseTable";
import HomeworkTable from "./components/teacher/homeworkTable";
import Header from "./components/header";
import { HubContext } from "./components/chat/HubContext";
import ProfileChat from "./components/profile/profileComponents/profileChat";
import ScoreData from "./components/profile/profileComponents/scoreData";
import ProfileData from "./components/profile/profileComponents/profileData";
import CourseData from "./components/profile/profileComponents/courseData";
import TaskData from "./components/profile/profileComponents/taskData";
import BuyCourse from "./components/course/BuyCourse";
import Footer from "./components/footer";


const App: FC<{}> = (): ReactElement => {
    loadUser()
    const hubCtx = useContext(HubContext);

    useEffect(() => {

        if (hubCtx?.connectionStarted) {
            hubCtx?.connection?.onclose(() => {
                console.log("Close Connection")
            });
        }
        if(hubCtx?.connection === undefined)
        {
            console.log("hubCtx == ", hubCtx?.connection)
            const token = localStorage.getItem('token');
            console.log("token == ", token)
            hubCtx?.startNewConnection(String(token))
        }
        
    }, [hubCtx?.connection]);
    
    return(
        <div>
            <AuthProvider userManager={userManager} hubCtx={hubCtx}>
                <Router>
                <Header userManage={userManager}/>
                    <Routes>
                        <Route path='/' Component={Home}/>
                        <Route path='/CourseList' Component={CourseList}/>
                        <Route path='/Profile' Component={ProfilePage}/>
                        <Route path='/Teacher' Component={TeacherPage}/>
                        <Route path='/Administrator' Component={AdministratorPage}/>
                        <Route path='/Course/:id' element={<CoursePage/>}/>
                        <Route path='/signin-oidc' Component={SignInOidc}/>
                        <Route path='/signout-oidc' Component={SignOutOidc}/>
                        <Route path='/CourseTable' Component={CourseTable}/>
                        <Route path='/CreateCourse' Component={CreateCourse}/>
                        <Route path="/TeacherCourses" Component={TeacherCourseTable}/>
                        <Route path='/EditCourse/:id' element={<EditCourse/>}/>
                        <Route path='/HomeworkTable/:id' element={<HomeworkTable/>}/>
                        <Route path='/ProfileChat' Component={ProfileChat}/>
                        <Route path='/ScoreData' Component={ScoreData}/>
                        <Route path='/ProfileData' element={<ProfileData userManager={userManager}/>}/>
                        <Route path='/CourseData' Component={CourseData}/>
                        <Route path='/TaskData' Component={TaskData}/>
                        <Route path='/BuyCourse/:id' element={<BuyCourse/>}/>
                    </Routes>
                </Router>
            </AuthProvider>
            <Footer/>
        </div>
    )
}

export default App
