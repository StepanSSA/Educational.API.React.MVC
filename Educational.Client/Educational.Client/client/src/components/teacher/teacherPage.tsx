
const TeacherPage = () => {
    return(
        <div className="adminPage conteiner">
        <h1>Страница учителя</h1>
        <div className='conteiner row'>
            <div className='adminFucnBtnsBlock col-lg-4'>
                <ul>
                    <li><a type ="button" href='/TeacherCourses' className='adminFucnBtn'>Список курсов</a></li>
                </ul>
            </div>
        </div>
    </div>
    )
}

export default TeacherPage;