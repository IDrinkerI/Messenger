import React from "react";
import { Message } from "../Message";
import "./message_field.scss";
import { useDispatch, useSelector } from "react-redux";
import { messagesSelector } from "./store/selectors";
import { useEffect } from "react";
import { initMessageStoreAction } from "./store/actions";


export const MessageField = () => {
    const dispatch = useDispatch();
    const messageList = useSelector(messagesSelector);

    //TODO: Use env variable
    if (process.env.NODE_ENV != "development")
        useEffect(() => dispatch(initMessageStoreAction()), []);

    return (
        <div className="message_field">
            {messageList?.map((item, index) =>
                <Message message={item} key={index} />
            )}
        </div>
    );
}
