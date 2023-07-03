import './footer.css'


const Footer = () => {
    return(
        <footer className='footer'>
            <div className='conteiner'>
                <div className='row'>
                    <div className='col'>
                        <ul className='list'>
                            <li className='listItem'>Организация: OOO "Образовательная платформа", 125167, г.Москва, Ленинградский пр-кт, д. 39, стр. 79, этаж 23, пом. XXXIV, часть комнаты 1</li>
                            <li className='listItem'>Контакты: +7 (952)-341-22-42, +7 (952)-341-22-40</li>
                            <li className='listItem'> OOO "Образовательная платформа" осуществляет деятельность в сфере информационных технологий (код вида деятельности согласно перечню, утверждённому Приказом Минцифры № 766 от 08.10.2022: 16.01).</li>
                        </ul>
                    </div>
                    <div className='col'>
                        <ul className='list'>
                            <li className='listItem'><a href='/' className='FooterBtn'>Политика конфиденциальности</a></li>
                            <li className='listItem'><a href='/' className='FooterBtn'>Оферта</a></li>
                            <li className='listItem'><a href='/' className='FooterBtn'>Сведения об организации</a></li>
                            <li className='listItem'><a href='https://minobrnauki.gov.ru/' className='FooterBtn'>Сайт Минобрнауки России</a></li>
                            <li className='listItem'><a href='https://edu.gov.ru/' className='FooterBtn'>Сайт Минпросвещения России</a></li>
                            <li className='listItem'><a href='/' className='FooterBtn'>Лицензия на курсы</a></li>
                        </ul>
                    </div>
                    <div className='col'>
                        <ul className='list'>
                            <li className='listItem'><a href='/CourseList' className='FooterBtn'>Курсы</a></li>
                            <li className='listItem'><a href='/' className='FooterBtn'>Главная</a></li>
                        </ul>
                    </div>
                </div>
            </div>
        </footer>
    )
}

export default Footer