import React from "react";
import { useDispatch, useSelector } from "react-redux";
import MessageModel from "../model/MessageModel";
import { updateInputMessageAction } from "../store/input_message/actions";
import { inputMessageSelector } from "../store/input_message/selectors";
import { addMessageAction } from "../store/message/actions";
import "../style/messenger.scss";
import Button from "./Button.jsx";
import ChatList from "./ChatList.jsx";
import InputField from "./InputField.jsx";
import MessageField from "./MessageField.jsx";


const Messenger = () => {
    const dispatch = useDispatch();
    const inputMessage = useSelector(inputMessageSelector);
    const buttonHandler = () => {
        dispatch(addMessageAction(new MessageModel("bot", inputMessage)));
        dispatch(updateInputMessageAction(""));
    }

    return (
        <div className="messenger">
            <div className="messenger_inner">
                <ChatList />
                <MessageField />
            </div>

            <div className="messenger_inner">
                <InputField />
                <Button onClick={buttonHandler}>Send</Button>
            </div>
        </div>
    );
}

export default Messenger;