import { MDBListGroupItem, MDBCardTitle, MDBCardText, MDBIcon } from 'mdb-react-ui-kit';

export default function BookListItem({ title, author, description }){
    return(
        <MDBListGroupItem className="d-flex flex-column bg-light p-4 mb-2">
            <div className="d-flex align-items-center mb-2">
                <MDBIcon fas icon="book-open" className="me-2 text-primary" />
                <MDBCardTitle className="h5 mb-0">{title}</MDBCardTitle>
            </div>
            <h6 className="text-muted mb-3">by {author}</h6>
            <MDBCardText>{description}</MDBCardText>
        </MDBListGroupItem>
    )
}