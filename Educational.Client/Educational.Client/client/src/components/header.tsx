import './header.css'
import { User, UserManager } from 'oidc-client';
import userManager, { signinRedirect, signoutRedirect } from '../auth/user-service';
import React from 'react';

class Header extends React.Component<{userManage: UserManager}, {header: JSX.Element}> {
    constructor(props: any) {
        super(props)

        this.state = {
            header: <header className="Header">
                        <nav>      
                            <input type="checkbox" name="menu" id="btn-menu" />
                            <label htmlFor="btn-menu">Меню</label> 
                            <ul>
                                <li><a type='button' href='/'>Главная</a></li>
                                <li><a type='button' href='/CourseList'>Курсы</a></li>
                                <li><button onClick={() => signinRedirect()}>Вход</button></li>
                            </ul>
                        </nav>
                    </header>
        }

        this.setState.bind(this.UserAuthorized)
        this.setState.bind(this.UserUnauthorized)

        this.CheckUser()

        userManager.events.removeUserLoaded(this.UserAuthorized)
        userManager.events.removeUserUnloaded(this.UserUnauthorized)

        userManager.events.addUserLoaded(this.UserAuthorized)
        userManager.events.addUserUnloaded(this.UserUnauthorized)
    }

    render(){ return(this.state.header) }

    CheckUser = async () =>
    {
        console.log("CheckUser")
        const user = await userManager.getUser()
        console.log("user", user)
        if(user !== null)
            this.UserAuthorized(user)
    }

    UserAuthorized = (user: User) =>
    {
        console.log("UserAuthorized //////////////////////////////////////////////////////////////////////////////")
        if(user?.profile['role'] === "Student")
        {
            this.setState( {header:
                <header className="Header">
                    <nav>      
                        <input type="checkbox" name="menu" id="btn-menu" />
                        <label htmlFor="btn-menu">Меню</label> 
                        <ul>
                            <li><a type='button' href='/'>Главная</a></li>
                            <li><a type='button' href='/CourseList'>Курсы</a></li>
                            <li><a type='button' href='/Profile'>{user?.profile.given_name ?? "Профиль"}</a></li>
                            <li><button onClick={() => signoutRedirect()}>Выход</button></li>
                        </ul>
                    </nav>
                </header>
            })
        }
        else if(user?.profile['role'] === "Teacher")
        {
            this.setState( {header:
                <header className="Header">
                    <nav>      
                        <input type="checkbox" name="menu" id="btn-menu" />
                        <label htmlFor="btn-menu">Меню</label> 
                        <ul>
                            <li><a type='button' href='/Teacher'>Панель учителя</a></li>
                            <li><a type='button' href='/'>Главная</a></li>
                            <li><a type='button' href='/Profile'>{user?.profile.given_name ?? "Профиль"}</a></li>
                            <li><button onClick={() => signoutRedirect()}>Выход</button></li>
                        </ul>
                    </nav>
                </header>
            })
        }
        else if(user?.profile['role'] === "Administrator")
        {
            this.setState( {header:
                <header className="Header">
                    <nav>      
                        <input type="checkbox" name="menu" id="btn-menu" />
                        <label htmlFor="btn-menu">Меню</label> 
                        <ul>
                            <li><a type='button' href='/Administrator'>Панель администратора</a></li>
                            <li><a type='button' href='/'>Главная</a></li>
                            <li><a type='button' href='/Profile'>{user?.profile.given_name ?? "Профиль"} </a></li>
                            <li><button onClick={() => signoutRedirect()}>Выход</button></li>
                        </ul>
                    </nav>
                </header>
            })
        }
        else{
            console.log("role not found")
            this.setState( {header:
                <header className="Header">
                    <nav>      
                        <input type="checkbox" name="menu" id="btn-menu" />
                        <label htmlFor="btn-menu">Меню</label> 
                        <ul>
                            <li><a type='button' href='/Teacher'>Панель учителя</a></li>
                            <li><a type='button' href='/Administrator'>Панель администратора</a></li>
                            <li><a type='button' href='/'>Главная</a></li>
                            <li><a type='button' href='/CourseList'>Курсы</a></li>
                            <li><a type='button' href='/Profile'>{user?.profile.email}</a></li>
                            <li><button onClick={() => signinRedirect()}>Вход</button></li>
                            <li><button onClick={() => signoutRedirect()}>Выход</button></li>
                        </ul>
                    </nav>
                </header>
            })
        }
    }

    UserUnauthorized = () =>
    {
        console.log("UserUnauthorized //////////////////////////////////////////////////////////////////////////////")
        this.setState( {header:
            <header className="Header">
                <nav>      
                    <input type="checkbox" name="menu" id="btn-menu" />
                    <label htmlFor="btn-menu">Меню</label> 
                    <ul>
                        <li><a type='button' href='/'>Главная</a></li>
                        <li><a type='button' href='/CourseList'>Курсы</a></li>
                        <li><button onClick={() => signinRedirect()}>Вход</button></li>
                    </ul>
                </nav>
            </header>
        })
    }
}





export default Header;