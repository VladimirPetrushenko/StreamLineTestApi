export const EMPTYANSWER = () => JSON.parse(JSON.stringify({
    id: EMPRYID,
    value: "",
    isRight: false
}));

export const EMPTYQUESTION = () => JSON.parse(JSON.stringify({
    id: EMPRYID,
    value: '',
    answers: [EMPTYANSWER()],
    type: 1
}));

export const EMPRYID = -1;