export class ClientBase{
    protected transformOptions(options: any )
    {
        const token = localStorage.getItem('token');
        options.headers = {
            ...options.headers, 
            Athorization: 'Bearer ' + token
        };
        return Promise.resolve(options);
    }
}