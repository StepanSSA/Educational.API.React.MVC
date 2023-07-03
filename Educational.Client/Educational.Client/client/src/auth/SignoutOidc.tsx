import React, { useEffect, FC } from 'react';
import { useNavigate } from "react-router-dom";
import { signoutRedirectCallback } from './user-service'

const SignOutOidc: FC<{}> = () => {
    const history =  useNavigate();
    useEffect(() => {
        async function signoutAsync() {
            await signoutRedirectCallback();
            history('/');
        }
        signoutAsync ();
    }, [history])

    return(
        <div style={{minHeight: "600px"}}>
            Redirecting...
        </div>
    );
};

export default SignOutOidc;