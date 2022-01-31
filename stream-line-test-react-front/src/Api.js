export const GetTestById = async (id) => {
    let response = await fetch(`https://localhost:7053/Test/id?Id=${id}`);
    return await response.json();
}

export const GetUpdateTestById = async (id) => {
    let response = await fetch(`https://localhost:7053/Test/update/id?Id=${id}`);
    return await response.json();
}

export const GetAllTests = async () => {
    const response = await fetch("https://localhost:7053/Test");
    return await response.json();
}

export const GetAllQuestions = async () => {
    let response = await fetch("https://localhost:7053/Question");
    return await response.json();
}

export const PostCheckTest = async (request) => {
    const value = {
        method: "POST",
        headers: {
            'accept': '*/*',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(request)
    };
    const response = await fetch("https://localhost:7053/Test/CheckTest", value);
    return await response.json();
}

export const PostCreateTest = async (request) => {
    const value = {
        method: "POST",
        headers: {
            'accept': '*/*',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(request)
    };
    const response = await fetch("https://localhost:7053/Test/Create", value);
    return await response.json();
}

export const PostCreateTestWithConstructor = async (request) => {
    const value = {
        method: "POST",
        headers: {
            'accept': '*/*',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(request)
    };
    const response = await fetch("https://localhost:7053/Test/CreateWithConstructor", value);
    return await response.json();
}

export const PutUpdateTest = async (id, request) => {
    const value = {
        method: "PUT",
        headers: {
            'accept': '*/*',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(request)
    };
    const response = await fetch(`https://localhost:7053/Test/update/id?id=${id}`, value);
    return await response.json();
}