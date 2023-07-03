import React, { useEffect, FC } from 'react';
import { useNavigate } from "react-router-dom";
import { signinRedirectCallback } from './user-service'


const SignInOidc: FC<{}> = () => {
    const history =  useNavigate();
    useEffect(() => {
        async function signinAsync() {
            await signinRedirectCallback();
            history('/');
            
        }
        signinAsync();
    }, [history])

    return(
        <div style={{minHeight: "600px"}}>
            Redirecting...
        </div>
    );
};

export default SignInOidc;