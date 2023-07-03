import { useParams } from "react-router";
import { Client, CourseDetailVm, CourseLookupDto, CreatePurchasedCoursesDto } from "../../api/api";
import { useState } from "react";
import { signinRedirect } from "../../auth/user-service";
import "./BuyCourse.css"


const BuyCourse = () => {
    const params = useParams();
    const apiClient = new Client("https://localhost:7083")
    const courseId = params.id?.split(":",2)[1];
    const [courseInfo, SetCourseInformation] = useState<CourseDetailVm>()

    if(courseInfo === undefined || courseInfo === null)
    {
        apiClient.getCourse(String(courseId)).then(value => {
            SetCourseInformation(value)
        })
    }

    var userId = localStorage.getItem('userId');
    if(userId === null || userId === undefined || userId === "")
    {
        signinRedirect()
    }
    if(userId !== null && userId !== undefined && userId !== "")
    {
        return(
            <div style={{paddingTop: "2rem", minHeight: "700px"}}>
                <div id="card-success" className="hidden">
                <i className="fa fa-check"></i>
                <p>Платёж прошёл успешно</p>
                </div>
                <div id="form-errors" className="hidden">
                <i className="fa fa-exclamation-triangle"></i>
                <p id="card-error">Ошибка</p>
                </div>
                <div id="form-container">

                <div id="card-front">
                    <div id="shadow"></div>
                    <div id="image-container">
                    <span id="amount">К оплате <strong>{courseInfo?.price} рублей</strong></span>
                    <span id="card-image">
                    
                        </span>
                    </div>
                    <label htmlFor="card-number">
                        Номер карты
                    </label>
                    <input className="input"  type="text" id="card-number" placeholder="1234 5678 9101 1112" maxLength={16}/>
                    <div id="cardholder-container">
                    <label htmlFor="card-holder">Владелец
                    </label>
                    <input className="input"  type="text" id="card-holder" placeholder="John Doe" />
                    </div>
                    <div id="exp-container">
                    <label htmlFor="card-exp">
                        Срок действия
                        </label>
                    <input className="input"  id="card-month" type="text" placeholder="MM" maxLength={2}/>
                    <input className="input"  id="card-year" type="text" placeholder="YY" maxLength={2}/>
                    </div>
                        <div id="cvc-container">
                    <label htmlFor="card-cvc"> CVC/CVV</label>
                    <input className="input"  id="card-cvc" placeholder="XXX-X" type="text" min-length="3" max-length="4"/>
                    <p>Последние 3 или 4 цифры</p>
                    </div>
                </div>
                <div id="card-back">
                    <div id="card-stripe">
                    </div>

                </div>
                <input className="input" type="text" id="card-token" />
                <button onClick={Buy} type="button" id="card-btn">Оплатить</button>

                </div>

                <script src="https://ajax.googleapis.com/ajax/libs/jquery/2.2.4/jquery.min.js"></script>
                <script type="text/javascript" src="https://js.stripe.com/v2/"></script>
                <script src="https://use.fontawesome.com/f1e0bf0cbc.js"></script>
            </div>
        )
    }
    return(
        <div>

        </div>
    )

    function Buy()
    {
        const cardNubmer = document.getElementById("card-number")?.textContent;
        const cardHolder = document.getElementById("card-holder")?.textContent;
        const cardMont = document.getElementById("card-month")?.textContent;
        const cardYear = document.getElementById("card-year")?.textContent;
        const cvv = document.getElementById("card-cvc")?.textContent;

        if( cardNubmer?.length === 16 && cardHolder?.split('').length === 2 && 
            cardMont?.length === 2 && Number(cardMont) < 12 && cardYear?.length === 2 &&
            cvv?.length === 3 || cvv?.length ||4)
        {
            console.log("courseInfo?.id == ",courseInfo?.id)
            const buyModel: CreatePurchasedCoursesDto = {
                coursId: courseId,
                date: new Date(Date.now()),
                purchasePrice: courseInfo?.price,
                userId: String(userId)
            }
            

            apiClient.buyCourse(buyModel).then(() => {
                document.getElementById("card-success")?.classList.remove("hidden")
                document.getElementById("form-errors")?.classList.add("hidden")
                document.getElementById("card-btn")?.classList.add("hidden")    
            }).catch(() => {
                document.getElementById("form-errors")?.classList.remove("hidden") 
                document.getElementById("card-success")?.classList.add("hidden") 
            })
        } 
        document.getElementById("card-success")?.classList.add("hidden")
        document.getElementById("form-errors")?.classList.remove("hidden")
    }
}

export default BuyCourse;