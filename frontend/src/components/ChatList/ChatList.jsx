import React, { useEffect } from "react";
import { useDispatch } from "react-redux";
import { useSelector } from "react-redux";
import { initChatListAction } from "./store/actions";
import { chatListSelector } from "./store/selectors";
import "./chatlist.scss";
import { Chat } from "../Chat";


export const ChatList = () => {
    const chats = useSelector(chatListSelector);
    const dispatch = useDispatch();

    //TODO: Use env variable
    if (process.env.NODE_ENV == "production")
        useEffect(() => dispatch(initChatListAction()), []);

    return (
        <div className="chatlist">
            <ul>
                {chats?.map((item) => <Chat chat={item} key={item.id} />)}
            </ul>
        </div>
    );
}
