import React from "react";
import { useSelector, useDispatch } from "react-redux";
import { selectChatAction } from "../store/chats/actions";
import { currentChatIdSelector } from "../store/chats/selectors";
import "../style/chat.scss";


const Chat = (props) => {
    const { id, name } = props.chat;
    const dispatch = useDispatch();
    const selectedChatId = useSelector(currentChatIdSelector);

    const onClickHadnler = () =>
        dispatch(selectChatAction(id));

    return (
        <li className={(id != selectedChatId) ? "chat" : "chat chat_current"} onClick={onClickHadnler}>
            {name}
        </li>
    )
}

export default Chat;