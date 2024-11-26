import { useContext, useEffect, useState } from 'react'
import { useNavigate } from 'react-router-dom'

import * as bookApi from '../api/bookApi'
import { errors } from '../common/constants/messages'
import { routes } from '../common/constants/api'
import { UserContext } from '../contexts/userContext'

export function useGetTopThree() {
    const { token } = useContext(UserContext)

    const [books, setBooks] = useState([])
    const [isFetching, setIsFetching] = useState(false)
    const [error, setError] = useState(null) 

    useEffect(() => {
        async function fetchData() {
            try {
                setIsFetching(true)
                setBooks(await bookApi.getTopThreeAsync(token))
            } catch (error) {
                setError(error.message)
            } finally {
                setIsFetching(false)
            }
        }

        fetchData()
    }, [token])

    return { books, isFetching, error } 
}

export function useGetFullInfo(id) {
    const { token } = useContext(UserContext)
    const user = useContext(UserContext)
    console.log(user);
    

    const navigate = useNavigate()
    const [book, setBook] = useState(null)
    const [isFetching, setIsFetching] = useState(false)

    const fetchData = async () => {
        try {
            setIsFetching(true)
            const fetchedBook = await bookApi.getDetailsAsync(id, token)
            setBook(fetchedBook)
        } catch (error) {
            navigate(routes.notFound, { state: { message: errors.book.notfound } })
        } finally {
            setIsFetching(false)
        }
    };

    useEffect(() => {
        fetchData()
    }, [id, token])

    return { book, isFetching, refreshBook: fetchData }
}

export function useCreate(){
    const { token } = useContext(UserContext) 
    
    const navigate = useNavigate()

    const createHandler = async (bookData) => {
        const book = {
            ...bookData,
            imageUrl: bookData.imageUrl || null,
            authorId: bookData.authorId || null,
            authorName: bookData.authorName || null,
            publishedDate: bookData.publishedDate || null
        }

        try {
            const bookId = await bookApi.createAsync(book, token)
            return bookId
        } catch (error) {
            navigate(routes.badRequest, { state: { message: error.message } })
        }
    }

    return createHandler
}

export function useEdit(){
    const { token } = useContext(UserContext) 

    const navigate = useNavigate()

    const editHandler = async (bookId, bookData) => {
        const book = {
            ...bookData,
            imageUrl: bookData.imageUrl || null,
            authorId: bookData.authorId || null,
            publishedDate: bookData.publishedDate || null
        }

        try {
            const isSuccessful = await bookApi.editAsync(bookId, book, token)
            return isSuccessful
        } catch (error) {
            navigate(routes.badRequest, { state: { message: error.message } })
        }
    }

    return editHandler
}
