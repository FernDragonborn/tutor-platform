class ReviewDTO {
    rating: number;
    commentatorName: string;
    date: string;
    subject: string;
    level: string;
    comment: string;

    constructor(rating: number, commentatorName: string, date: string, subject: string, level: string, comment: string) {
        this.rating = rating;
        this.commentatorName = commentatorName;
        this.date = date;
        this.subject = subject;
        this.level = level;
        this.comment = comment;
    }
}