import './home.css'

const CourseView = () =>{
    return(
        <div className='CourseView'>
            <div className='ImgBox'>
                <img className='ViewImg' 
                    src="https://w0.peakpx.com/wallpaper/165/963/HD-wallpaper-c-sharp-c-code-c-programmer-code-developers.jpg" alt=''/> 
            </div>
            <h4>C# для начинающих</h4>
            <p>
                В этом курсе вы разберёте основы современного языка программирования C#
            </p>
            <button className='ViewBtn'>Подробнее</button>
        </div>
    )
}

export default CourseView