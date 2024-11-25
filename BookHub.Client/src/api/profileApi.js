import { baseUrl, routes } from '../common/constants/api'
import { errors } from '../common/constants/messages'

export async function getAsync(token, userId) {
    const options = {
        method: "GET",
        headers: {
            'Authorization': `Bearer ${token}`
        }
    }

    const url = baseUrl + routes.profile + `/${userId}`
    const response = await fetch(url, options)

    if(response.ok){
        return await response.json()
    } else if (response.status === 404){
        return null
    } 

    throw new Error(errors.profile.get)
}

export async function createAsync(profile, token){
    const options = {
        method: "POST",
        headers: {
            'Authorization': `Bearer ${token}`,
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(profile)
    }

    const url = baseUrl + routes.profile
    const response = await fetch(url, options)

    if(response.ok){
        return await response.json()
    }

    throw new Error(errors.profile.create)
}

export async function editAsync(profile, token){
    const options = {
        method: "PUT",
        headers: {
            'Authorization': `Bearer ${token}`,
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(book)
    }

    const url = baseUrl + routes.profile
    const response = await fetch(url, options)

    if(response.ok){
        return true
    }

    throw new Error(errors.profile.edit)
}

export async function deleteAsync(token){
    const options = {
        method: "DELETE",
        headers: {
            'Authorization': `Bearer ${token}`
        }
    }

    const url = baseUrl + routes.books
    const response = await fetch(url, options)

    if(response.ok){
        return true 
    }

    return false
}