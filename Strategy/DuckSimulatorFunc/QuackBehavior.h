#pragma once

#include <iostream>
#include <functional>

typedef std::function<void()> QuackBehavior;

void QuackQuack();

void Squeak();

void MuteQuack();