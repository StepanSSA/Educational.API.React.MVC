import './profilePage.css'



const ProfilePage = () =>
{
    const role = localStorage.getItem('role');

    if(role == "Teacher")
    {
        return(
            <div style={{minHeight: "600px"}} className="profilePage conteiner">
            <h1>Профиль</h1>
            <div className='conteiner row' style={{paddingTop: "1rem"}}>
                <div className='profileFucnBtnsBlock col-lg-2'>
                    <ul className='BtnsLi' >
                        <li><a href='/ProfileData' type="button" className='profileFucnBtn'>Профиль</a></li>
                        <li><a href='/ProfileChat' type="button" className='profileFucnBtn'>Чат</a></li>
                    </ul>
                </div>
            </div>
        </div>
        )
    }
    if(role == "Administrator")
    {
        return(
            <div style={{minHeight: "600px"}} className="profilePage conteiner">
            <h1>Профиль</h1>
            <div className='conteiner row' style={{paddingTop: "1rem"}}>
                <div className='profileFucnBtnsBlock col-lg-2'>
                    <ul className='BtnsLi' >
                        <li><a href='/ProfileData' type="button" className='profileFucnBtn'>Профиль</a></li>
                    </ul>
                </div>
            </div>
        </div>
        )
    }
    return(
        <div style={{minHeight: "600px"}} className="profilePage conteiner">
        <h1>Профиль</h1>
        <div className='conteiner row' style={{paddingTop: "1rem"}}>
            <div className='profileFucnBtnsBlock col-lg-2'>
                <ul className='BtnsLi' >
                    <li><a href='/ProfileData' type="button" className='profileFucnBtn'>Профиль</a></li>
                    <li><a href='/CourseData' type="button" className='profileFucnBtn'>Мои курсы</a></li>
                    <li><a href='/ProfileChat' type="button" className='profileFucnBtn'>Чат</a></li>
                    <li><a href='/ScoreData' type="button" className='profileFucnBtn'>Оценки</a></li>
                </ul>
            </div>
        </div>
    </div>
    )
    

}

export default ProfilePage