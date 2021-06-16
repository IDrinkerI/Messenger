
export class RestClient {
    static API = "/api/";

    static getAsync = async (apiPath) => {
        var response = await fetch(this.API + apiPath);
        var result = await response.json();
        return result;
    }

    static postAsync = async (apiPath, newState) => {
        await fetch(this.API + apiPath, {
            method: "POST",
            headers: { "Content-Type": "application/json" },
            body: JSON.stringify(newState)
        });
    }

    static putAsync = async (apiPath, dispatchObject) => {
        await fetch(this.API + apiPath, {
            method: "PUT",
            headers: { "Content-Type": "application/json" },
            body: JSON.stringify(dispatchObject)
        });
    }

    static deleteAsync = async (apiPath, dispatchObject) => {
        await fetch(this.API + apiPath, {
            method: "DELETE",
            headers: { "Content-Type": "application/json" },
            body: JSON.stringify(dispatchObject)
        });
    }
}
