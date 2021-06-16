
export class RestClient {
    static API = "/api/";

    static get = async (apiPath) => {
        var response = await fetch(this.API + apiPath);
        var result = await response.json();
        return result;
    }

    static post = async (apiPath, newState) => {
        await fetch(this.API + apiPath, {
            method: "POST",
            headers: { "Content-Type": "application/json" },
            body: JSON.stringify(newState)
        });
    }

    static put = async (apiPath, dispatchObject) => {
        await fetch(this.API + apiPath, {
            method: "PUT",
            headers: { "Content-Type": "application/json" },
            body: JSON.stringify(dispatchObject)
        });
    }

    static delete = async (apiPath, dispatchObject) => {
        await fetch(this.API + apiPath, {
            method: "DELETE",
            headers: { "Content-Type": "application/json" },
            body: JSON.stringify(dispatchObject)
        });
    }
}
