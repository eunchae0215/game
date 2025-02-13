const mongoose = require('mongoose');
const express = require('express');
const bodyParser = require('body-parser');
const cors = require('cors');

// Express 앱 생성
const app = express();

// 미들웨어 설정
app.use(bodyParser.json());
app.use(cors());

// MongoDB 연결
const uri = "mongodb+srv://s2uh9yun:sh04020900@gamet.lpmyb.mongodb.net/?retryWrites=true&w=majority&appName=Gamet";
mongoose.connect(uri).then(() => {
    console.log("Connected to MongoDB!");
}).catch(err => {
    console.error("Failed to connect to MongoDB:", err);
});

// 사용자 스키마 및 모델 (id, password, nickname 필드 사용)
const userSchema = new mongoose.Schema({
    id: String,
    password: String,
    nickname: String
});
const User = mongoose.model('User', userSchema);

// 회원가입 API
app.post("/register", async (req, res) => {
    try {
        const { id, password, nickname } = req.body;
        
        // 이미 동일 id가 있는지 확인
        const existingUser = await User.findOne({ id });
        if (existingUser) {
            return res.json({ success: false, message: "User ID already exists" });
        }

        // 새 사용자 생성
        const newUser = new User({ id, password, nickname });
        await newUser.save();

        res.json({ success: true, message: "User registered successfully!" });
    } catch (error) {
        console.error(error);
        res.json({ success: false, message: "Registration failed" });
    }
});

// 로그인 API
app.post("/login", async (req, res) => {
    try {
        const { id, password } = req.body;
        const user = await User.findOne({ id, password });

        if (user) {
            res.json({ success: true, message: "Login successful", user });
        } else {
            res.json({ success: false, message: "Invalid id or password" });
        }
    } catch (error) {
        console.error(error);
        res.json({ success: false, message: "Login failed" });
    }
});

// 서버 실행
const PORT = 3000;
app.listen(PORT, () => {
    console.log(`Server is running on http://localhost:${PORT}`);
});