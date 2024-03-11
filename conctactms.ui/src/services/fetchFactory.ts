export type HttpMethod = 'GET' | 'POST' | 'PUT' | 'PATCH' | 'DELETE';
const baseUrl = "https://localhost:7167/"

const getAntiforgeryHeader = () => {
    const requestVerificationToken =
        document?.cookie
            ?.split('; ')
            ?.find(row => row.startsWith('CSRF-TOKEN'))
            ?.split('=')[1] ?? '';

    return { RequestVerificationToken: requestVerificationToken };
};

const ajaxHeader = {
    'X-Requested-With': 'XMLHttpRequest'
};
const jsonContentType = 'application/json';
const token = localStorage.getItem('token');

const jsonContentTypeHeader = {
    accept: jsonContentType,
    'content-type': jsonContentType,
    'Authorization': `Bearer ${token}`,
    ...ajaxHeader
};

const getOutput = async (response: Response) => {
    const contentType = response.headers.get('content-type');
    if (contentType?.includes(jsonContentType)) {
        return response.json();
    }
    return undefined;
};

const fetchFactory = (method: HttpMethod) => {
    const getHeaders = ['POST', 'PUT', 'PATCH', 'DELETE'].find(x => x === method)
        ? (isFormData: boolean) =>
            isFormData
                ? { ...getAntiforgeryHeader(), ...ajaxHeader }
                : { ...getAntiforgeryHeader(), ...jsonContentTypeHeader }
        : (isFormData: boolean) => (isFormData ? ajaxHeader : jsonContentTypeHeader);

    return async function fetch<TInput = unknown | FormData, TOutput = unknown>(path: string, input?: TInput): Promise<TOutput> {
        const isFormData = input instanceof FormData;

        if (path.startsWith('/'))
            path = path.substring(1);

        const response = await window
            .fetch(`${baseUrl}${path}`, {
                method,
                body: isFormData ? input : JSON.stringify(input),
                headers: getHeaders(isFormData)
            });

        const output = await getOutput(response);
        return response.ok
            ? output
            : Promise.reject({
                response: {
                    status: response.status,
                    data: output ?? (response.status === 401 ? undefined : await response.json())
                }
            });
    };
};

export const get: <TOutput = unknown>(path: string) => Promise<TOutput> = fetchFactory('GET');
export const post = fetchFactory('POST');
export const put = fetchFactory('PUT');
export const patch = fetchFactory('PATCH');
export const del = fetchFactory('DELETE');