import React, { Component } from "react"
import './courseItem.css'

interface DefaultProps {
    id: string | undefined;
    Name: string | undefined;
    Duration: number | undefined;
    Description: string | undefined;
    Price: number | undefined;
}

export class CourseItem extends Component<DefaultProps>{
    path = () =>{return "/Course/:" + this.props.id}
    
    render(){
    return(
        <div className="CourseItemBackground">
            <div className="ImgContainer"> 
                <img className="ViewImgCourse" alt="" src="https://cdo-curriculum.s3.amazonaws.com/media/uploads/img_tag.png"/>
            </div>
            <div className="TextContainer">
                <h3>{this.props.Name}</h3>
                <p>{this.props.Description}</p>
                <h5>{this.props.Price}p</h5>
            </div>
            <a type="button" className="ViewBtn" href={this.path()}>Посмотреть</a>
        </div>
    )};
}

export default CourseItem