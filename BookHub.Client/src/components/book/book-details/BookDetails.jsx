import { useContext, useState } from "react"
import { useParams, useNavigate } from "react-router-dom"

import * as bookApi from '../../../api/bookApi'
import * as useBook from '../../../hooks/useBook'
import { routes } from "../../../common/constants/api"
import { UserContext } from "../../../contexts/userContext"

import BookFullInfo from './book-full-info/BookFullInfo'
import AuthorIntroduction from './author-introduction/AuthorIntroduction'
import DefaultSpinner from '../../common/default-spinner/DefaultSpinner'

import './BookDetails.css'

export default function BookDetails() {
    const { id } = useParams()
    const { userId, token } = useContext(UserContext)
    const { book, isFetching } = useBook.useGetFullInfo(id)
    const [showFullDescription, setShowFullDescription] = useState(false)
    const navigate = useNavigate()

    async function deleteHandler() {
        await bookApi.deleteAsync(id, token)
        navigate(routes.books)
    }

    const creatorId = book ? book.creatorId : null
    const isCreator = userId === creatorId

    const previewTextLength = 200
    const descriptionPreview = book?.longDescription?.slice(0, previewTextLength)

    return (
        !isFetching ? (
            book ? (
                <div className="book-details-container mt-5">
                    <div className="book-details-card shadow-lg p-4">
                        <BookFullInfo
                            book={book}
                            descriptionPreview={descriptionPreview}
                            showFullDescription={showFullDescription}
                            setShowFullDescription={setShowFullDescription}
                            isCreator={isCreator}
                            deleteHandler={deleteHandler}
                            id={id}
                        />
                        <AuthorIntroduction author={book.author} />
                    </div>
                </div>
            ) : (
                <div className="book-not-found mt-5">
                    <div className="alert alert-danger text-center" role="alert">
                        <h4 className="alert-heading">Oops!</h4>
                        <p>The book you are looking for was not found.</p>
                    </div>
                </div>
            )
        ) : (
            <div className="spinner-container d-flex justify-content-center align-items-center">
                <DefaultSpinner />
            </div>
        )
    )
}