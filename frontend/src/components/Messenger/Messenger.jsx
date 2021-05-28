import React from "react";
import { useDispatch, useSelector } from "react-redux";
import { MessageModel } from "../../model/MessageModel";
import { Button } from "../Button";
import { ChatList } from "../ChatList";
import { InputField, inputMessageSelector, updateInputMessageAction } from "../InputField";
import { MessageField, addMessageAction} from "../MessageField";
import "./messenger.scss";


export const Messenger = () => {
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