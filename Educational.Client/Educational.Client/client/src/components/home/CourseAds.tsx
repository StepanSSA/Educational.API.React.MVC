
const CourseAds = () => {
    return(
        <div className="CourseAds">
            <div className="CourseAdscontent">
                <div className="row">
                    <h3 className="CourseAdsTitle">Этот курс подойдет тем, кто</h3>
                </div>
                <div className="row justify-content-md-center">
                    <div className="col">
                        <div className="TextBlock">
                            <p className="PTitle">Никогда не работал</p>
                            <p className="PText">
                            и хочет получить востребованную специальность, трудоустроиться или узнать больше о специальности
                            </p>
                        </div>
                    </div>
                    <div className="col">
                    <div className="TextBlock">
                            <p className="PTitle">Хочет сменить работу</p>
                            <p className="PText">
                            освоить современные инструменты, технологии и получить актуальную высокооплачиваемую специальность
                            </p>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    )
}

export default CourseAds;