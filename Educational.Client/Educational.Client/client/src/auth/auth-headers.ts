export function setAuthHeader(token: string | null | undefined) {
    console.log("Token "+token);
    localStorage.setItem('token', token ? token : '');
}