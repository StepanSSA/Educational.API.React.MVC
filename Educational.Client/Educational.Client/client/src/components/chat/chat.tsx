
const Chat = () => {
    return(
            <section>
            <div className="container ChatBlock">

                <div className="row d-flex justify-content-center">
                <div className="col-md-10 col-lg-8 col-xl-6">

                    <div className="card" id="chat2">

                    <div className="card-body" data-mdb-perfect-scrollbar="true" style={{position: "relative", height: "400px"}}>
                        <div className="d-flex flex-row justify-content-end mb-4">
                        <div>
                            <p className="small p-2 me-3 mb-1 text-white rounded-3 bg-primary">Текст сообщения</p>
                            <p className="small me-3 mb-3 rounded-3 text-muted d-flex justify-content-end">00:11</p>
                        </div>
                        <img src="https://mdbcdn.b-cdn.net/img/Photos/new-templates/bootstrap-chat/ava4-bg.webp"
                            alt="avatar 1" style={{width: "45px", height: "100%"}}/>
                        </div>

                        <div className="d-flex flex-row justify-content-start mb-4">
                        <img src="https://mdbcdn.b-cdn.net/img/Photos/new-templates/bootstrap-chat/ava3-bg.webp"
                            alt="avatar 1" style={{width: "45px", height: "100%"}}/>
                        <div>
                            <p className="small p-2 ms-3 mb-1 rounded-3" style={{backgroundColor: "#f5f6f7"}}>Текст сообщения</p>
                            <p className="small ms-3 mb-3 rounded-3 text-muted">00:13</p>
                        </div>
                        </div>
                    </div>

                    <div className="card-footer text-muted d-flex justify-content-start align-items-center p-3">
                        <img src={"https://mdbcdn.b-cdn.net/img/Photos/new-templates/bootstrap-chat/ava3-bg.webp"}
                        alt="avatar 3" style={{width: "40px", height: "100%"}}/>
                        <input type="text" className="form-control form-control-lg ChatInput" id="exampleFormControlInput1"
                        placeholder="Отправить сообщение..."/>
                        <input type="button" />
                    </div>

                    </div>

                </div>
                </div>

            </div>
            </section>
    )
}

export default Chat