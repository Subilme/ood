#pragma once

#include <iostream>
#include <functional>

typedef std::function<void()> FlyBehavior;

FlyBehavior FlyWithWings();

void FlyNoWay();