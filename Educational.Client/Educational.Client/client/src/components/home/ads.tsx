import './ads.css'


const Ads = () => {
    return(
        <div className='main'>
            <h1 style={{paddingBottom: "1rem"}}>Компаниям нужны специалисты с ИТ-навыками</h1>
            <p className='adsText'>
                ИТ-специалист — это представитель одной из более чем 500 цифровых профессий, связанных с разработкой программ и 
                использованием компьютерной техники.
                Глобализация сделала сферу ИТ одной из самых высокооплачиваемых: российским компаниям приходится конкурировать с 
                зарубежными за хороших специалистов. 
                Экономика и повседневная жизнь все больше переходит в «цифру», поэтому у ИТ-сферы многообещающие перспективы.
            </p>
            <div className='row'>
                <div className='col'>
                    <ul className='ulList'>
                        <li className='ulText'><p className='ulTitle'>Востребованно</p> <p className='ulText'>За 2021 количество вакансий на рынке ИТ выросло на 72%. Количество резюме — всего на 6% </p></li>
                    </ul>
                </div>
                <div className='col'>
                    <ul className='ulList'>
                        <li className='ulText'><p className='ulTitle'>Перспективно</p> <p className='ulText'>К 2035 году в России будет более 2,5 млн вакансий для специалистов из сферы ИТ</p></li>
                    </ul>
                </div>
                <div className='col'>
                    <ul className='ulList'>
                        <li className='ulText'><p className='ulTitle'>Высокооплачиваемо</p> <p className='ulText'>Зарплата начинающего ИТ-специалиста — от 60 000 ₽. А уже через три года — от 150 000 ₽</p></li>
                    </ul>
                </div>
            </div>
        </div>
    )
}

export default Ads