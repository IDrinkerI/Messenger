import React from "react";
import "../style/chatlist.scss";
import Chat from "./Chat.jsx";


const ChatList = () => {
    const chats = [
        "chat 1",
        "chat 2",
        "chat 3",
        "chat 4",
    ];

    return (
        <div className="chatlist">
            <ul>
                {chats.map(item => <Chat name={item} />)}
            </ul>
        </div>
    );
}

export default ChatList;