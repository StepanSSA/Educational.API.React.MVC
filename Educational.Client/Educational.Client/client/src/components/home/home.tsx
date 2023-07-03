import './home.css'
import CourseView from './courseView'
import Ads from './ads'

const Home = () =>{
    return(
        <div>
            <div className='header'>
                <h1>Образовательная платформа</h1>
            </div>
            <div className='firstSection'>
                <div className='firstSection_text_block'>
                    <h1>
                        <span>Смените профессию</span>
                        <span>Научитесь новому</span>
                        <span>Найдите себя</span>
                    </h1>
                    <p>
                    Обучаем с нуля профессиям и предоставляем знания по востребованным специальностям и направлениям в сфере Информационных технологий.
                    </p>
                    <div>
                        <p>
                        Длительные программы обучения, короткие интенсивные программы и обширная база знаний
                        </p>
                        <p>
                        Лекции, семинары, вебинары, мероприятия, статьи, видеоматериалы и другие форматы 
                        </p>
                        <p>
                        Крупнейшее сообщество ИТ-специалистов, экспертов, выпускников и новичков   
                        </p>
                    </div>
                </div>
                <CourseView/>
            </div>
            <div>
                <Ads/>
            </div>
        </div>
    )
}

export default Home