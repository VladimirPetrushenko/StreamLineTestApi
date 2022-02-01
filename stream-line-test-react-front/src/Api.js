export const GetTestById = async (id) => {
    const value = createRequest("GET");
    const response = await fetch(`https://localhost:7053/Test/id?Id=${id}`, value).then(checkForError);
    return response;
}

export const GetUpdateTestById = async (id) => {
    const value = createRequest("GET");
    const response = await fetch(`https://localhost:7053/Test/update/id?Id=${id}`, value).then(checkForError);
    return response;
}

export const GetAllTests = async () => {
    const value = createRequest("GET");
    const response = await fetch("https://localhost:7053/Test", value).then(checkForError);
    return response;
}

export const GetAllQuestions = async () => {
    const value = createRequest("GET");
    const response = await fetch("https://localhost:7053/Question", value).then(checkForError);
    return response;
}

export const PostCheckTest = async (request) => {
    const value = createRequest("POST", request); 
    const response = await fetch("https://localhost:7053/Test/CheckTest", value).then(checkForError);
    return response;
}

export const PostCreateTest = async (request) => {
    const value = createRequest("POST", request); 
    const response = await fetch("https://localhost:7053/Test/Create", value).then(checkForError);
    return response;
}

export const PostCreateTestWithConstructor = async (request) => {
    const value = createRequest("POST", request); 
    const response = await fetch("https://localhost:7053/Test/CreateWithConstructor", value).then(checkForError);
    return response;
}

export const PutUpdateTest = async (id, request) => {
    const value = createRequest("PUT", request); 
    const response = await fetch(`https://localhost:7053/Test/update/id?id=${id}`, value).then(checkForError);
    return response;
}

export const PostCreateUser = async (request) => {
    const value = createRequest("POST", request); 
    const response = await fetch("https://localhost:7053/register", value).then(checkForError);
    return response;
}

export const PostLoginUser = async (request) => {
    const value = createRequest("POST", request);
    const response = await fetch("https://localhost:7053/login", value).then(checkForError);
    return response;
}

export const GetLogout = async () => {
    const value = createRequest("GET"); 
    const response = await fetch("https://localhost:7053/logout", value).then(response => {
        if(!response.ok){
            throw Error(response.statusText);
        }
    });
    return response;
}

export const CheckUser = async () => {
    const value = createRequest("GET");
    const response = await fetch("https://localhost:7053/user", value).then(checkForError);
    return response;
}

function createRequest(type, body){
    const value = {
        method: type,
        headers: {
            'accept': '*/*',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(body),
        credentials: 'include'
    };

    return value;
}

const checkForError = response => {
    if(response.ok){
        return response.json();
    }
    else{
        throw Error(response.statusText);
    }
};