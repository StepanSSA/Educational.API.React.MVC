import './adminPage.css'

const AdministratorPage = () =>{
    return(
        <div className="adminPage conteiner">
            <h1>Страница администратора</h1>
            <div className='conteiner row'>
                <div className='adminFucnBtnsBlock col-lg-4'>
                    <ul>
                        <li><a type ="button" href='https://localhost:7086/Auth/RegisterTeacher?returnUrl=http://localhost:3000/Administrator' className='adminFucnBtn'>Зарегестрировать учителя</a></li>
                        <li><a type ="button" href='/CourseTable' className='adminFucnBtn'>Список курсов</a></li>
                    </ul>
                </div>
            </div>
        </div>
    )
}

export default AdministratorPage
