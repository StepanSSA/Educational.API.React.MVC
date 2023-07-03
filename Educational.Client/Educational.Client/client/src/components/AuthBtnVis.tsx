import { useState } from "react"
import { signinRedirect, signoutRedirect } from "../auth/user-service"

const AuthBtnVis = () => {
    
    const [buttons, setButtons] = useState<JSX.Element>()
    const token = ""
    console.log(token)

    if(token === null){
        setButtons(<button onClick={() => signinRedirect()} >Вход</button>)
    }
    else
    {
        setButtons(
            <ul>
                <li><a type='button' href='/Profile'>Профиль</a></li>
                <li><button onClick={() => signoutRedirect()} >Выход</button></li>
            </ul>
        )
    }

    return(
        buttons
    )
    
}

export default AuthBtnVis