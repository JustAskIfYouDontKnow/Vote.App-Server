﻿using Telegram.Bot.Types.ReplyMarkups;

namespace BottApp.Host.Keyboards;

public class Keyboard
{

    public static InlineKeyboardMarkup MainKeyboardMarkup = new(
        new[]
        {
            // first row
            new []
            {
                InlineKeyboardButton.WithCallbackData("Голосование 🗳 ", "ButtonVotes"),
                InlineKeyboardButton.WithCallbackData("Сказать привет ✋ ", "ButtonHi"),
                
            },
            // second row
            new []
            {
                InlineKeyboardButton.WithCallbackData("Help❕ ", "ButtonHelp"),
            },
        });
    public static InlineKeyboardMarkup MainVotesKeyboardMarkup = new(
        new[]
        {
            // first row
            new []
            {
                InlineKeyboardButton.WithCallbackData("Оставить голос", "ButtontGiveAVote"),
                
            },
            // second row
            new []
            {
                InlineKeyboardButton.WithCallbackData("Добавить своего кандидата", "ButtonAddCandidate"),
            },
            // third row
            new []
            {
                InlineKeyboardButton.WithCallbackData("Back", "ButtonBack"),
                InlineKeyboardButton.WithCallbackData("Help", "ButtonHelp"),
            },
        });
    
    public static InlineKeyboardMarkup VotesKeyboardMarkup = new(
        new[]
        {
            // first row
            new []
            {
                InlineKeyboardButton.WithCallbackData("< ", nameof(MenuButton.ButtonLeft)),
                InlineKeyboardButton.WithCallbackData(" >", nameof(MenuButton.ButtonRight)),
            },
            // second row
            new []
            {
                InlineKeyboardButton.WithCallbackData("Like", "ButtonLike"),
            },
            // third row
            new []
            {
                InlineKeyboardButton.WithCallbackData("Back", "ButtonBackToVotes"),
                InlineKeyboardButton.WithCallbackData("Help", "ButtonHelp"),
            },
        });
    
    public static InlineKeyboardMarkup ApproveDeclineKeyboardMarkup = new(
        new[]
        {
            // first row
            new []
            {
                InlineKeyboardButton.WithCallbackData("Approve", "ButtonApprove"),
                InlineKeyboardButton.WithCallbackData("Decline", "ButtonDecline"),
            },
        });
    
    
   public static ReplyKeyboardMarkup RequestLocationAndContactKeyboard = new(
        new[]
        {
            KeyboardButton.WithRequestContact("Поделиться контактом"),})

   {
        ResizeKeyboard = true,
        //OneTimeKeyboard = true
    };
   
    public const string usage = "Usage:\n" +
                         "/votes       - send votes keyboard\n" +
                         "/keyboard    - send custom keyboard\n" +
                         "/remove      - remove custom keyboard\n" +
                         "/photo       - send a photo\n" +
                         "/request     - request location or contact\n" +
                         "/inline_mode - send keyboard with Inline Query\n" +
                         "/help        - Раздел в разработке";
}