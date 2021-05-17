import React, { useEffect } from "react";
import { useDispatch } from "react-redux";
import { useSelector } from "react-redux";
import { initChatListAction } from "../store/chats/actions";
import { chatListSelector } from "../store/chats/selectors";
import "../style/chatlist.scss";
import Chat from "./Chat.jsx";


const ChatList = () => {
    const chats = useSelector(chatListSelector);
    const dispatch = useDispatch();

    useEffect(() => dispatch(initChatListAction()), []);

    return (
        <div className="chatlist">
            <ul>
                {chats?.map((item) => <Chat name={item.name} key={item.id} />)}
            </ul>
        </div>
    );
}

export default ChatList;