import React, {FC, ReactNode, useEffect, useRef} from 'react'
import { User, UserManager } from "oidc-client"
import { setAuthHeader } from './auth-headers';

type AuthProviderProps = {
    userManager: UserManager;
    children: ReactNode;
    hubCtx: any;
}

const AuthProvider: FC<AuthProviderProps> = ({
    userManager: manager,
    children,
    hubCtx: context
}) : any => {
    
    let userManager = useRef<UserManager>();
    useEffect(() => {
        userManager.current = manager;
        const onUserLoaded = (user: User) => {
            console.log('user loaded', user);
            const token = user?.access_token;
            setAuthHeader(token);

            context?.startNewConnection(String(token))
            console.log("connection ", context )

            var role = String(user?.profile['role'])
            localStorage.setItem('role', role ? role: '')
        };
        const onUserUnloaded = () => {
            setAuthHeader(null);
            localStorage.setItem('userId', '')
            localStorage.setItem('role', '')
            console.log('user unloaded');
        };
        const onAccessTokenExpiring = () => {
            console.log('user token expiring');
        };
        const onAccessTokenExpired = () => {
            console.log('user token expired');
        };
        const onUserSignedOut = () => {
            console.log("hubCtx == ", context)
            context?.connection?.stop()
            console.log('user signed out');
        };

        userManager.current.events.addUserLoaded(onUserLoaded);
        userManager.current.events.addUserUnloaded(onUserUnloaded);
        userManager.current.events.addAccessTokenExpiring(onAccessTokenExpiring);
        userManager.current.events.addAccessTokenExpired(onAccessTokenExpired);
        userManager.current.events.addUserSignedOut(onUserSignedOut);

        return function cleanup() {
            if(userManager && userManager.current)
            {
                userManager.current.events.removeUserLoaded(onUserLoaded);
                userManager.current.events.removeUserUnloaded(onUserUnloaded);
                userManager.current.events.removeAccessTokenExpiring(onAccessTokenExpiring);
                userManager.current.events.removeAccessTokenExpired(onAccessTokenExpired);
                userManager.current.events.removeUserSignedOut(onUserSignedOut);
            }
        }
    }, [manager])

    return React.Children.only(children);
};

export default AuthProvider;