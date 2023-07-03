import { useContext, useEffect, useRef, useState } from "react";
import { ClientChat, MessageModel, UserDialogs } from "../../../api/api"
import { HubContext } from "../../chat/HubContext";
import { Message } from "../../chat/message";

const ProfileChat = () => {
  var chatService = new ClientChat('https://localhost:44323');
  var userId = localStorage.getItem('userId');
  const hubCtx = useContext(HubContext);

  useEffect(() => {
    if(hubCtx?.messages?.length !== reciveMessages.length)
    {
      var copy = hubCtx?.messages as Message[]
      for (let index = 0; index < copy.length; index++) {
        SetReciveMessages(recive => [...reciveMessages, copy[index]]); 
        AddMessage(copy[index].message, copy[index].username);
      }
      console.log("recive");
    } 
  }, [])
  
  useEffect(() => {
    if (scroll && scroll.current) {
      const { scrollHeight, clientHeight } = scroll.current;
      scroll.current.scrollTo({ left: 0, top: scrollHeight - clientHeight });
    }
    var copy = hubCtx?.messages as Message[]
    for (let index = 0; index < copy.length; index++) {
      if(!reciveMessages.includes(copy[index]))
      {
        SetReciveMessages(recive => [...reciveMessages, copy[index]]); 
        AddMessage(copy[index].message, copy[index].username);
      }
    }

  }, [hubCtx?.messages]);

  const input = useRef<any>();
  const scroll = useRef<HTMLDivElement>(null);
  const [reciveMessages, SetReciveMessages] = useState<Message[]>([])
  const [sendedMessage, SetSendedMessage] = useState<string>();
  const [activeRecipient, SetActiveRecipient] = useState<string>();
  const [messageModule, SetMessageModule] = useState<JSX.Element[]>([]);
  const [dialogModule, SetDialogModule] = useState<JSX.Element[]>([]);

  const [load, setLoad] = useState<boolean>(true)
    if(load)
    {
      chatService.getUserDialogs(String(userId)).then(value => {
        if(value == null || value == undefined)
        {
          setLoad(false)
          return
        }
        console.log("diag == ", value)
        CreateDialogModule(value)
        setLoad(false)
      })
    }
    return(
        <div className="container">
        <div className="messaging">
              <div className="inbox_msg">
                <div className="inbox_people">
                  <div className="inbox_chat">
                   <div className="chat_list active_chat">
                      <div className="chat_people">
                        {dialogModule.map(item => (
                          <div className="row">{item}</div>
                        ))}
                      </div>
                    </div>
                  </div>
                </div>
                <div ref={scroll} className="mesgs">
                  <div className="msg_history">
                    {messageModule}
                  </div>
                  <div className="type_msg">
                    <div className="input_msg_write">
                      <input ref={input} id="MessageInput" onChange={(e) => SetSendedMessage(e.target.value)} type="text" className="write_msg" placeholder="Отправить сообщение..." />
                      <button onClick={SendMessage} className="msg_send_btn" type="button"><i className="fa fa-paper-plane-o" aria-hidden="true"></i></button>
                    </div>
                  </div>
                </div>
              </div>
            </div></div>
    )

    function CreateDialogModule(value: UserDialogs[])
    {
      var item = dialogModule;
      item.splice(0, dialogModule.length)

      for (let index = 0; index < value.length; index++) {
        const newModule = ( <div style={{paddingBottom: "10px"}} onClick={() => ChangeDialog(String(value[index].interlocutorId))}>
                              <div className="chat_img"> <img src="https://ptetutorials.com/images/user-profile.png" alt="sunil"/> </div>
                              <div className="chat_ib">
                                <h5> {value[index].interlocutor} <span className="chat_date"></span></h5>
                              </div>
                              <br></br>
                            </div>)
        
        item.push(newModule);
        SetDialogModule(item);
      }
      return dialogModule
    }

    function CreateMessageModule(value: MessageModel[])
    {
      var item = messageModule;
      item.splice(0, messageModule.length)

      for (let index = 0; index < value.length; index++) {
        var newModule: JSX.Element
        console.log("senderId == ", value[index].senderId)
        console.log("userId", userId)
        if(value[index].senderId == userId)
        {
          newModule = ( <div className="outgoing_msg">
                          <div className="sent_msg">
                            <p>{value[index].messageText}</p>
                            <span className="time_date"> </span> </div>
                        </div>)
        }
        else
        {
           newModule =  <div className="incoming_msg">
                            <div className="incoming_msg_img"> <img src="https://ptetutorials.com/images/user-profile.png" alt="sunil"/> </div>
                            <div className="received_msg">
                              <div className="received_withd_msg">
                                <p>{value[index].messageText}</p>
                                <span className="time_date"></span></div>
                            </div>
                          </div>
                        
        }
        
        item.push(newModule);
        SetMessageModule(item);
      }
    }

    function ChangeDialog(id: string)
    {
      chatService.getDialogMessages(id, String(userId)).then(value => {
        console.log("value == ", value);
        if(value === null || value === undefined)
          return

        SetActiveRecipient(id)
        CreateMessageModule(value)
        console.log(messageModule)
      })
    }

    function AddMessage(message : string, id: string)
    {
      var newModule: JSX.Element
      if(id == userId)
        {
          newModule = ( <div ref={scroll} className="outgoing_msg">
                          <div className="sent_msg">
                            <p>{message}</p>
                            <span className="time_date"> </span> </div>
                        </div>)
        }
        else
        {
           newModule = (<div ref={scroll} className="outgoing_msg">
                          <div className="sent_msg">
                            <p>{message}</p>
                            <span className="time_date"> </span> </div>
                        </div>)
        }

        var item = messageModule;
        item.push(newModule);
        SetMessageModule(item);
    }

    async function SendMessage()
    {
      var userId = localStorage.getItem('userId');
      if(userId === null && userId === undefined)
      {
          alert("Ошибка")
          return;
      }
      console.log("== ", hubCtx?.connection)
      await hubCtx?.connection?.invoke("SendMessageRecipientAsync", userId, sendedMessage, activeRecipient)
      AddMessage(String(sendedMessage), String(userId))
      SetSendedMessage("")
      input.current.value = ''
    }

}

export default ProfileChat