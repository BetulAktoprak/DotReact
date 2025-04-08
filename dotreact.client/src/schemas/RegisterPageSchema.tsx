import * as yup from 'yup';

export const registerPageSchema = yup.object().shape({
    username: yup.string().required("Kullanıcı adı boş geçilemez"),
    email: yup.string().required("Email adresi boş geçilemez"),
    password: yup.string().required("Şifre boş geçilemez")
});