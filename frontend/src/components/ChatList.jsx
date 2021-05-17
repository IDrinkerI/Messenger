import React from "react";
import { useSelector } from "react-redux";
import { chatListSelector } from "../store/chats/selectors";
import "../style/chatlist.scss";
import Chat from "./Chat.jsx";


const ChatList = () => {
    const chats = useSelector(chatListSelector);

    return (
        <div className="chatlist">
            <ul>
                {chats?.map((item, index) => <Chat name={item} key={index} />)}
            </ul>
        </div>
    );
}

export default ChatList;