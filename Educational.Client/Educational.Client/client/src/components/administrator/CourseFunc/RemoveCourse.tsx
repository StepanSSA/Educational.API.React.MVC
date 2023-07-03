import { Component } from "react";
import { Client } from "../../../api/api";
import './RemoveCourse.css'

interface DefaultProps{
    courseId: string,
    name: string,
    description: string
}

export class RemoveCourse extends Component<DefaultProps>{
    render(){
        return(
            <div className="CourseInfo">
                <h2>{this.props.name}</h2>
                <p>{this.props.description}</p>
                <button onClick={()=>this.Remove} type="button">Удалить</button>
            </div>
    )};

    Remove()
    {
        const apiClient = new Client("https://localhost:7083")
        apiClient.deleteCourse(this.props.courseId);
    }
}

export default RemoveCourse