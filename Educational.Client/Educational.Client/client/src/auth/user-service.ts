import { UserManager, UserManagerSettings } from "oidc-client";
import { setAuthHeader } from "./auth-headers";


const userManagerSettings: UserManagerSettings = {
    client_id: "educ-web-client",
    redirect_uri: 'http://localhost:3000/signin-oidc',
    response_type: 'code',
    scope: 'openid profile CustomResource EducWebAPI  EducChat',
    authority: 'https://localhost:7086',
    post_logout_redirect_uri: 'http://localhost:3000/signout-oidc',
    loadUserInfo: true,
};

const userManager = new UserManager(userManagerSettings);
export async function loadUser() {
    const user = await userManager.getUser();
    const token = user?.access_token;
    setAuthHeader(token);
    
    const userId = user?.profile.sub;
    console.log("UserId "+ userId);
    localStorage.setItem('userId', userId ? userId : '');
}

export const signinRedirect = () => { 
    console.log("Sign In")    
    userManager.signinRedirect()
}

export const signinRedirectCallback = () => userManager.signinRedirectCallback()

export async function signoutRedirect() {
    const user = await userManager.getUser();
    if(user == null)
        return;
    userManager.clearStaleState();
    userManager.removeUser();
    return userManager.signoutRedirect({ 'id_token_hint': user?.id_token });
}

export const signoutRedirectCallback = () => {
    userManager.clearStaleState();
    userManager.removeUser();
    return userManager.signoutRedirectCallback();
}

export default userManager;