import { User, UserManager } from "oidc-client";
import userManager from "../../../auth/user-service";
import { useState } from "react";

interface IProp{
    userManager: UserManager;
}

const ProfileData = (prop: IProp) =>{

    const [user, setUser] = useState<User>();
    if(user === undefined || user === null)
    {
        userManager.getUser().then(value => {
            setUser(value as User)
            console.log(value);
        })
    }
    return(
        <div className="profileBlock" style={{minHeight: "700px"}}>
            <ul className="profileUl">
                <li className="listItem">Имя: {user?.profile.given_name}</li>
                <li className="listItem">Фамилия: {user?.profile.family_name}</li>
                <li className="listItem">Email: {user?.profile.email}</li>
                <li className="listItem">Должность: {user?.profile['role']}</li>
            </ul>
        </div>
    )

}

export default ProfileData