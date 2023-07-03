import { Client } from "../../api/api";


const GetLesson = () =>{
    const apiClient = new Client("https://localhost:7083"); 
    return(
        <div>
            <button onClick={() => GetLesson()}>Получить уроки</button>
        </div>
    )

    async function GetLesson() {
        const response = await apiClient.getLessons("");
        console.log(response)
    }
}

export default GetLesson;